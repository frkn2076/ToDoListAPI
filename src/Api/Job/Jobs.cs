using Api.Extension;
using Api.Utils.Models;
using Data.Contracts;
using Hangfire;
using Service.Notifier;

namespace Api.Job;

public static class Jobs
{
    public static async Task InitJobsAsync(this WebApplication app)
    {
        var repository = app.Services.GetRequiredService<IRepository>();
        var notificationSettings = app.Configuration.GetOptions<NotificationSettings>();

        var completedTasks = await repository.GetCompletedTasksQueryAsync();

        foreach (var completedTask in completedTasks)
        {
            RecurringJob.AddOrUpdate($"myrecurringjob-{completedTask.UserName}",
                () => MailSender.SendMail(completedTask.UserName, notificationSettings.Email, notificationSettings.Password, completedTask.Count),
                Cron.Daily(completedTask.TimeZone));
        }
    }
}
