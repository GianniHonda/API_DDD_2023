using Entidades.Notificacoes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Entidades
{
    [Table("TB_NOTICIA")]
    public class Noticia : Notifica
    {
        [Column("NIC_ID")]
        public int Id { get; set; }

        [Column("NIC_TITULO")]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Column("NIC_INFORMACAO")]
        [MaxLength(255)]
        public string Informacao { get; set; }

        [Column("NIC_ATIVO")]
        public bool Ativo { get; set; }

        [Column("NIC_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow; // Salva a data em UTC

        [Column("NIC_DATA_ALTERACAO")]
        public DateTime DataAlteracao { get; set; } = DateTime.UtcNow; // Salva a data em UTC

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}