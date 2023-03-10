# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

## Assignment 9&10

The purpose of this assignment is to solidify your learning of multithreaded programing
with the Task Parallel Library (TPL).

### Due Dates

- Assignment 9&10 is due (even though you are pairing) **Monday March 20, 11:59 PM.**
- Code reviews (be everyone individually) are due **Wednesday March 22, 11:59 PM**. (Thus all PRs will be reviewed twice.)
- Final PR is due **Thursday March 23, 11:59 PM**.
- **The combination of Assignment 9&10 will be graded - starting Friday March 24.**

## Reading

- Chapter 19: Introducing Multithreading
- Chapter 21: Iterating in Parallel

Previously Assigned

- Chapter 20: Programming with Task-Based Asynchronous Pattern
- Chapter 22: Thread Synchronization

## Instructions

1. Implement `PingProcess`' `public Task<PingResult> RunTaskAsync(string hostNameOrAddress)` ❌✔
   - First implement `public void RunTaskAsync_Success()` test method to test `PingProcess.RunTaskAsync()` using `"localhost"`. ❌✔
   - Do NOT use async/await in this implementation. ❌✔
2. Implement `PingProcess`' `async public Task<PingResult> RunAsync(string hostNameOrAddress)` ❌✔
   - First implement the `public void RunAsync_UsingTaskReturn_Success()` test method to test `PingProcess.RunAsync()` using `"localhost"` **without** using async/await. ❌✔
   - Also implement the `async public Task RunAsync_UsingTpl_Success()` test method to test `PingProcess.RunAsync()` using `"localhost"` but this time **DO** using async/await. ❌✔
3. Add support for an optional cancellation token to the `PingProcess.RunAsync()` signature. ❌✔
   Inside the `PingProcess.RunAsync()` invoke the token's `ThrowIfCancellationRequested()` method so an exception is thrown. ❌✔
   Test that, when cancelled from the test method, the exception thrown is an `AggregateException` ❌✔ with a `TaskCanceledException` inner exception ❌✔ using the test methods `RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping` ❌✔and `RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException` ❌✔ respectively.
4. Complete/fix **AND test** `async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)` which executes ping for and array of hostNameOrAddresses (which can all be "localhost") **in parallel**, adding synchronization if needed. ❌✔
   NOTE:
      - The order of the items in the stdOutput is irrelevent and expected to be intermingled.
      - StdOutput must have all the ping output returned (no lines can be missing) even though intermingled. ❌✔
5. Implement **AND test** `public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)` using `Task.Factory.StartNew()` and invoking `RunProcessInternal` with a `TaskCreation` value of `TaskCreationOptions.LongRunning` and a `TaskScheduler` value of `TaskScheduler.Current`. Returning a `Task<PingResult>` is also okay.
   NOTE: This method does **NOT** use `Task.Run`.

## Extra Credit

- Test and implement `PingProcess.RunAsync(System.IProgress<T> progess)` so that you can capture the output as it occurs rather than capturing the output only when the process finishes. ❌✔

## Fundamentals

- Place all shared project properties into a `Directory.Build.Props` file.
- Place all shared project items into a `Directory.Build.targets` file.
- Ensure nullable reference types is enabled  ❌✔
- Ensure that you turn on code analysis for all projects(EnableNETAnalyzers)  ❌✔
- Set `LangVersion` and the `TargetFramework` to the latest released versions available (preview versions optional)   ❌✔
- and enabled .NET analyzers for both projects ❌✔
- For this assignment, consider using `Assert.AreEqual<T>()` (the generic version)  ❌✔
- All of the above should be unit tested ❌✔
- Choose simplicity over complexity ❌✔
