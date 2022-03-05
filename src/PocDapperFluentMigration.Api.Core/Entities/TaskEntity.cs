using PocDapperFluentMigration.Api.Core.Enum;
using PocDapperFluentMigration.Shared.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PocDapperFluentMigration.Api.Core.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("task")]
    public class TaskEntity : IntIdEntityBase
    {
        public string Detalhes { get; set; }
        public bool Concluida { get; set; } = false;
        public string Identificador { get; set; } = Guid.NewGuid().ToString();
        public int TotalPomodoros { get; set; } = 0;
        public int TotalParadasCurtas { get; set; } = 0;
        public int TotalParadasLongas { get; set; } = 0;
        public TimeSpan TotalTempoPomodoro { get; set; } = TimeSpan.Zero;
        public TimeSpan TotalTempoParadas { get; set; } = TimeSpan.Zero;
        public int TempoPomodoro { get; set; } = 25;
        public int TempoParadaCurta { get; set; } = 5;
        public int TempoParadaLonga { get; set; } = 15;
        public string TextoConclusao { get; set; } = "Tempo concluído.";
        public TipoExecucaoTempo TipoTempoPomodoro { get; set; } = TipoExecucaoTempo.Minutos;
        public TipoExecucaoTempo TipoTempoParadaCurta { get; set; } = TipoExecucaoTempo.Minutos;
        public TipoExecucaoTempo TipoTempoParadaLonga { get; set; } = TipoExecucaoTempo.Minutos;
    }
}
