using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocDapperFluentMigration.Api.Application.Migrations
{
    [Migration(202203050002, "TabelaTask")]
    public class TabelaTask202203050002 : Migration
    {
        public override void Down()
        {
            Delete.Table("task");
        }
        public override void Up()
        {
            this.Execute.Sql(@"
                CREATE TABLE `task` (
                  `id` int(11) NOT NULL AUTO_INCREMENT,
                  `criadoEm` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                  `ultimaAlteracaoEm` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                  `removidoEm` datetime DEFAULT NULL,
                  `foiRemovido` bit(1) NOT NULL,
                  `detalhes` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
                  `concluida` bit(1) NOT NULL,
                  `identificador` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
                  `totalPomodoros` int(11) NOT NULL,
                  `totalParadasCurtas` int(11) NOT NULL,
                  `totalParadasLongas` int(11) NOT NULL,
                  `totalTempoPomodoro` time NOT NULL,
                  `totalTempoParadas` time NOT NULL,
                  `tempoPomodoro` int(11) NOT NULL,
                  `tempoParadaCurta` int(11) NOT NULL,
                  `tempoParadaLonga` int(11) NOT NULL,
                  `textoConclusao` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
                  `tipoTempoPomodoro` int(11) NOT NULL,
                  `tipoTempoParadaCurta` int(11) NOT NULL,
                  `tipoTempoParadaLonga` int(11) NOT NULL,
                  PRIMARY KEY (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
            ");
        }
    }
}
