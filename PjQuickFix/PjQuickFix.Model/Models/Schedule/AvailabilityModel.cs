using Microsoft.AspNetCore.Components;
using PjQuickFix.Model.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PjQuickFix.Model
{
    public class AvailabilityModel : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> Context { get; set; }

        public Tabs SelectedTab { get; set; } = Tabs.Single;

        public object CurrentUser { get; set; }
        public ScheduleItem NewScheduleItem { get; set; } = new ScheduleItem() { };
        public RecurringSchedule NewRecurringSchedule { get; set; }
        [Inject]
        public ScheduleState MyScheduleState { get; set; }
        [Inject]
        public IScheduleRepository ScheduleRepository { get; set; }
        public ScheduleItemViewModel ItemViewModel { get; set; }

        public DateTime DayViewStart => DateTime.Today.AddHours(8);
        public DateTime DayViewEnd => DateTime.Today.AddHours(20);

        public Schedule MySchedule { get; set; } = null;
        private DateTime SelectedDate { get; set; } = DateTime.Today;

        private DateTime ThisMonth { get { return new DateTime(SelectedDate.Year, SelectedDate.Month, 1); } }

        public ClaimsPrincipal _User;

        protected override async Task OnInitializedAsync()
        {
            var state = await Context;
            _User = state.User;
            this.MyScheduleState.ScheduleId = _User.GetClaimValueAsInt(UserInfo.Claims.SCHEDULEID).Value;

            this.ResetScheduleItem();
            this.MySchedule = await ScheduleRepository.GetAvailability(MyScheduleState.ScheduleId);

            this.MyScheduleState.SelectDate(SelectedDate);
            this.MyScheduleState.Schedule = MySchedule;
            await ExpandSchedule();
            StateHasChanged();
        }

        private async Task ExpandSchedule()
        {

            var fetchedTimeslots = await ScheduleRepository.FetchTimeSlots(MySchedule.Id);
            Console.WriteLine($"Fetched {fetchedTimeslots.Length} timeslots");
            MyScheduleState.TimeSlots.AddRange(fetchedTimeslots);
            Console.WriteLine($"MyScheduleState: {MyScheduleState.GetHashCode()}");
        }

        public async Task<IEnumerable<ValidationResult>> AddNewRecurringSchedule()
        {

            var results = NewRecurringSchedule.Validate(null);
            if (results.Any()) return results;
            await ScheduleRepository.AddNewRecurringSchedule(this.MySchedule, NewRecurringSchedule);

            this.MyScheduleState.ScheduleUpdated();

            this.ResetScheduleItem();
            return new ValidationResult[] { };
        }

        public async Task<IEnumerable<ValidationResult>> AddNewScheduleItem()
        {


            NewScheduleItem.Status = ScheduleStatus.NotAvailable;

            var results = this.NewScheduleItem.Validate(null); // <<-- That's not right...
            if (results.Any()) return results;

            await ScheduleRepository.AddNewScheduleItem(MySchedule, NewScheduleItem);

            this.MyScheduleState.ScheduleUpdated();

            this.ResetScheduleItem();
            return new ValidationResult[] { };
        }

        private void ResetScheduleItem()
        {
            this.NewScheduleItem = new ScheduleItem()
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today.AddDays(1)
            };
            this.NewRecurringSchedule = new RecurringSchedule()
            {
                MinStartDateTime = DateTime.Today,
                MaxEndDateTime = DateTime.Today.AddDays(7),
            };
        }

        public void ClickTab(Tabs tab)
        {
            SelectedTab = tab;
        }

        public class ScheduleItemViewModel
        {

            [Required]
            public string Name { get; set; }

            [Required]
            public string StartDateTime { get; set; }

            [Required]
            public string EndDateTime { get; set; }
        }
    }
}