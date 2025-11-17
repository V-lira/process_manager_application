using System;
using System.Diagnostics;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        Console.WriteLine("launching an external process");
        try
        {
            Process process = procceess();
            if (process != null)
            {
                info_processsss(process);
                waaait(process);
                info(process);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
        }
        Console.WriteLine("press any key to exit...");
        Console.ReadKey();
    }
    static Process procceess()
    {
        Console.WriteLine("\npress any key to exit...:");
        Console.WriteLine("1 - Calculator (calc.exe)");
        Console.WriteLine("2 - Notepad (notepad.exe)");
        Console.WriteLine("3 - CMD (cmd.exe)");
        Console.WriteLine("4 - Paint (mspaint.exe)");
        Console.WriteLine("5 - Explorer (explorer.exe)");
        Console.Write("your choice (1-5): ");
        string choice = Console.ReadLine();
        try
        {
            switch (choice)
            {
                case "1":
                    return staaaaart("calc.exe", "Calculator");

                case "2":
                    return staaaaart("notepad.exe", "Notepad");

                case "3":
                    return staaaaart("cmd.exe", "CMD");

                case "4":
                    return staaaaart("mspaint.exe", "Paint");

                case "5":
                    return staaaaart("explorer.exe", "Explorer");

                default:
                    Console.WriteLine("WRONG CHOICE!!! default launching notepad");
                    return staaaaart("notepad.exe", "Notepad");
            }
        }
        catch (Win32Exception ex)
        {
            Console.WriteLine($"error with laungching... -> {ex.Message}");
            Console.WriteLine("trying to launch notepad...");
            return staaaaart("notepad.exe", "Notepad");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"unexpected error: {ex.Message}");
            return null;
        }
    }
    static Process staaaaart(string fileName, string processName)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal
            };

            Process process = Process.Start(startInfo);
            Console.WriteLine($"\nprocess '{processName}' success!!!");
            return process;
        }
        catch (Win32Exception ex)
        {
            Console.WriteLine($"\nERROR: failed to launch {processName}");
            Console.WriteLine($"systen error -> {ex.Message}");
            throw;//Passing the exception on to SelectAndStartProcess for processing
        }
    }
    static void info_processsss(Process process)
    {
        try
        {
            Console.WriteLine("\ninfo");
            Console.WriteLine($"PID (process ID): {process.Id}");
            Console.WriteLine($"Process name: {process.ProcessName}");
            Console.WriteLine($"launch time: {process.StartTime}");
            Console.WriteLine($"priority: {process.BasePriority}");
            Console.WriteLine($"memory: {process.WorkingSet64 / 1024} KB");
            if (!string.IsNullOrEmpty(process.MainWindowTitle))
            {
                Console.WriteLine($"WINDOW NAME: {process.MainWindowTitle}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"no to complete information about the process: {ex.Message}");
        }
    }
    static void waaait(Process process)
    {
        Console.WriteLine("\nwait to exit...");
        Console.WriteLine("exit for continue");
        process.WaitForExit();
        Console.WriteLine("process done!");
    }
    static void info(Process process)
    {
        Console.WriteLine("\ninfo after exit");
        Console.WriteLine($"time to exit: {DateTime.Now}");
        Console.WriteLine($"key: {process.ExitCode}");
        Console.WriteLine($"avg working time: {process.ExitTime - process.StartTime}");
    }
}