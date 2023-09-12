using Microsoft.Data.Sqlite;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var dbFilePath = "xxx.db";

        await DoSomeDbWorkAsync(dbFilePath, cancellationToken).ConfigureAwait(false);

        File.Delete(dbFilePath);
    }

    private static async Task DoSomeDbWorkAsync(string dbFilePath, CancellationToken cancellationToken)
    {
        await using var connection = new SqliteConnection($"Data Source={dbFilePath}");
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
    }
}