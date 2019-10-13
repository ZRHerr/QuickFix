using Microsoft.Extensions.DependencyInjection;
using PjQuickFix.Model.Models;

namespace PjQuickFix.Model
{
    public static class ExtensionsModel
    {
        public static void AddModels(this IServiceCollection services)
        {
            services.AddTransient<AvailabilityViewModel>();
            services.AddTransient<DayPickerViewModel>();
            services.AddTransient<DayViewViewModel>();
            services.AddTransient<ManagerScheduleViewViewModel>();
            services.AddTransient<NavMenuViewModel>();
            services.AddTransient<RecurrenceDataEntryViewModel>();
        }
    }
}
