/*
As soon as we start a Task, it's execution starts (even without await).
await is just fo wait till the task is finisded, which is useful for writing async code in a more conventional way.
What happens if a task is started but not awaited:
    1. If the caller thread (which created the task) itself completes before the task is finished then the task remains incomplete.
    2. If the caller thread (which created the task) doesn't complete before the task is finished then the task also completes.
*/

Task t1 = Method1();
Task t2 = Method2();
await t1;
Console.WriteLine("Done!");
/* Output:
Starting method 1...
Starting method 2...
Completed method 2!
Completed method 1!
Done! 
*/

t1 = Method1();
t2 = Method2();
await t2;
Console.WriteLine("Done!");
/* Output:
Starting method 1...
Starting method 2...
Completed method 2!
Done! 
*/

async Task Method1()
{
    Console.WriteLine("Starting method 1...");
    await Task.Delay(3000);
    Console.WriteLine("Completed method 1!");
}

async Task Method2()
{
    Console.WriteLine("Starting method 2...");
    await Task.Delay(1000);
    Console.WriteLine("Completed method 2!");
}


