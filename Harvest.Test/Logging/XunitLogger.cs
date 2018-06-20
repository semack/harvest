﻿using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using Xunit.Abstractions;

namespace Harvest.Test.Logging
{
	public class XunitLogger : ILogger
	{
		private static readonly string[] NewLineChars = { Environment.NewLine };
		private readonly string _category;
		private readonly LogLevel _minLogLevel;
		private readonly ITestOutputHelper _output;

		public XunitLogger(ITestOutputHelper output, string category, LogLevel minLogLevel)
		{
			_minLogLevel = minLogLevel;
			_category = category;
			_output = output;
		}

		public void Log<TState>(
			LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel))
			{
				return;
			}

			// Buffer the message into a single string in order to avoid shearing the message when running across multiple threads.
			var messageBuilder = new StringBuilder();

			var firstLinePrefix = $"| {_category} {logLevel}: ";
			var lines = formatter(state, exception).Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
			messageBuilder.Append(firstLinePrefix).AppendLine(lines.FirstOrDefault());

			var additionalLinePrefix = "|" + new string(' ', firstLinePrefix.Length - 1);
			foreach (var line in lines.Skip(1))
			{
				messageBuilder.Append(additionalLinePrefix).AppendLine(line);
			}

			if (exception != null)
			{
				lines = exception.ToString().Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
				additionalLinePrefix = "| ";
				foreach (var line in lines.Skip(1))
				{
					messageBuilder.Append(additionalLinePrefix).AppendLine(line);
				}
			}

			// Remove the last line-break, because ITestOutputHelper only has WriteLine.
			var message = messageBuilder.ToString();
			if (message.EndsWith(Environment.NewLine))
			{
				message = message.Substring(0, message.Length - Environment.NewLine.Length);
			}

			try
			{
				_output.WriteLine(message);
			}
#pragma warning disable RCS1075 // Avoid empty catch clause that catches System.Exception.
			catch (Exception)
#pragma warning restore RCS1075 // Avoid empty catch clause that catches System.Exception.
			{
				// We could fail because we're on a background thread and our captured ITestOutputHelper is
				// busted (if the test "completed" before the background thread fired).
				// So, ignore this. There isn't really anything we can do but hope the
				// caller has additional loggers registered
			}
		}

		public bool IsEnabled(LogLevel logLevel)
			=> logLevel >= _minLogLevel;

		public IDisposable BeginScope<TState>(TState state)
			=> new NullScope();

		private class NullScope : IDisposable
		{
			public void Dispose()
			{
			}
		}
	}

	public class XunitLogger<T> : ILogger<T>, IDisposable
	{
		private readonly ITestOutputHelper _output;

		public XunitLogger(ITestOutputHelper output)
		{
			_output = output;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_output.WriteLine(state.ToString());
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return this;
		}

		public void Dispose()
		{
		}
	}
}