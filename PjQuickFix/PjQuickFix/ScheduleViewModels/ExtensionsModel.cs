using Microsoft.Extensions.DependencyInjection;
using PjQuickFix.Model;

namespace PjQuickFix.Web
{
    public static class ExtensionsModel
    {
        public static void AddModels(this IServiceCollection services)
        {
            services.AddTransient<AvailabilityModel>();
            services.AddTransient<DayPickerModel>();
            services.AddTransient<DayViewModel>();
            services.AddTransient<ManagerScheduleModel>();
            services.AddTransient<NavMenuModel>();
            services.AddTransient<ReocurrenceDataEntryModel>();
        }
    }
}
