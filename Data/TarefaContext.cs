using System.Data;

namespace MinimalAPICore.Data;

public class TarefaContext
{
    public delegate Task<IDbConnection> GetConnection();
}
