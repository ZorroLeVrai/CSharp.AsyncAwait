# AsyncAwaitTest
This code is used to illustrate how Async/Await functions work

Let's say that you put the following code in the main function
```
public static void Main()
{
  var task = WaitNTimesAsync("method1", 5, 9);
  task3.Wait();
}
```

The above code executes each async method `WaitNTimes` one after the other. 
The lines are displayed one after the other with a delay between each line.

Now consider this code
```
public static void Main()
{
  var task = WaitNTimesAsync("method1", 5, 9);
  var task2 = WaitNTimesAsync("method2", 5, 9);
  Task.WaitAll(task, task2);
}
```

This time since we are not awaiting the `WaitNTimesAsync` async functions, both functions are executed at the same time.
The lines are displayed 2 by 2 with a delay between each 2 lines.

and finally this code
```
public static void Main()
{
  var task3 = WaitAllAsync("method waitAll", 5, 9);
  task3.Wait();
}

```

In this case, all async methods are called simultaneously and all the lines are displayed at once.