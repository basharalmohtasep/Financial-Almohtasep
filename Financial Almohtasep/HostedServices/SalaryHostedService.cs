using Financial_Almohtasep.Data;
using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Services.EmployeeServices.TransactionServices;

namespace Financial_Almohtasep.HostedServices;

public class SalaryHostedService(ILogger<SalaryHostedService> _logger, IServiceProvider _serviceProvider) : IHostedService, IDisposable
{
    private Timer _timer;

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Salary Hosted Service starting.");

        ScheduleNextRun();

        return Task.CompletedTask;
    }

    private void ScheduleNextRun()
    {
        DateTime now = DateTime.Now;
        DateTime lastDayOfMonth = new(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

        // Run at 00:00 on the last day (you can change this time as needed)
        DateTime runTime = new(lastDayOfMonth.Year, lastDayOfMonth.Month, lastDayOfMonth.Day, 0, 0, 0);

        if (now > runTime)
        {
            // It's already past the time today — schedule for next month's last day
            var nextMonth = now.AddMonths(1);
            lastDayOfMonth = new DateTime(nextMonth.Year, nextMonth.Month, DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));
            runTime = new DateTime(lastDayOfMonth.Year, lastDayOfMonth.Month, lastDayOfMonth.Day, 0, 0, 0);
        }

        TimeSpan delay = runTime - now;

        _timer = new Timer(DoWork, null, delay, Timeout.InfiniteTimeSpan); // One-time timer
        _logger.LogInformation("Next salary run scheduled for {RunTime}", runTime);
    }

    private void DoWork(object state)
    {
        _logger.LogInformation("Salary processing running at: {Time}", DateTime.Now);

        // Do your actual work here...
        using (var scope = _serviceProvider.CreateScope())
        {
            var _employeeTransactionServices = scope.ServiceProvider.GetRequiredService<IEmployeeTransactionServices>();

            // Do your actual work here with dbContext
            _employeeTransactionServices.AddMonthlySalary().GetAwaiter().GetResult();

            _logger.LogInformation("Salary data processed and saved.");
        }

        // Schedule the next run
        ScheduleNextRun();
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Salary Hosted Service stopping.");

        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
