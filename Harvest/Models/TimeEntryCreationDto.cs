using System;
using Harvest.Dtos;
using Refit;

namespace Harvest.Models
{
	/// <summary>
	/// Time entry given by the Harvest API.
	/// </summary>
	public class TimeEntryCreationDto : CreationDto
	{
		/// <summary>
		/// The ID of the user to associate with the time entry. Defaults to the currently authenticated user’s ID.
		/// </summary>
		[AliasAs("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// The ID of the project to associate with the time entry.
		/// </summary>
		[AliasAs("project_id")]
		public long ProjectId { get; set; }

		/// <summary>
		/// The ID of the task to associate with the time entry.
		/// </summary>
		[AliasAs("task_id")]
		public long TaskId { get; set; }

		/// <summary>
		/// The ISO 8601 formatted date the time entry was spent.
		/// </summary>
		public DateTime SpentDate
		{
			get => DateTime.Parse(SpentDateApi);
			set => SpentDateApi = value.ToString("yyyy-MM-ddTHH:mm:ssZ");
		}

		[AliasAs("spentDate")]
		public string SpentDateApi { get; private set; }

		/// <summary>
		/// 	The ISO 8601 formatted date and time the timer was started. Defaults to the current time.
		/// </summary>
		[AliasAs("timer_started_at")]
		public string TimerStartedAt { get; set; }

		/// <summary>
		/// The current amount of time tracked. Defaults to 0.0.
		/// </summary>
		[AliasAs("hours")]
		public decimal? Hours { get; set; }

		/// <summary>
		/// Any notes to be associated with the time entry.
		/// </summary>
		[AliasAs("notes")]
		public string Notes { get; set; }

		/// <summary>
		/// An object containing the id, group_id, and permalink of the external reference.
		/// </summary>
		[AliasAs("external_reference")]
		public ExternalReferenceCreationDto ExternalReference { get; set; }
	}
}
