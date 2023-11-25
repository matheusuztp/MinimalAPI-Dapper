
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPICore.Data;

[Table("Tarefas")]
public record Tarefa(int id, string Atividade, string Status);