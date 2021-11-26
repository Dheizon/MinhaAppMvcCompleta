using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoTesteMapping : IEntityTypeConfiguration<EnderecoTeste>
    {
        public void Configure(EntityTypeBuilder<EnderecoTeste> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(p => p.IBGE)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.Property(p => p.SIAFI)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.ToTable("EnderecoTeste");

        }
    }
}
