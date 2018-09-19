using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using hemopet.Core.Models;
using MvvmHelpers;

namespace hemopet.Core.Services.Remote.Clinica
{
    public class FakeClinicaService : IClinicaService
    {
        ObservableRangeCollection<Models.Clinica> clinicas = new ObservableRangeCollection<Models.Clinica>()
        {
            new Models.Clinica{Id = 1, Nome = "Clínica Veterinária Quatro Patas"},
            new Models.Clinica{Id = 2, Nome = "Clínica Veterinária Mundo Animal"},
            new Models.Clinica{Id = 3, Nome = "Hospital Veterinario do Trabalhador"},
            new Models.Clinica{Id = 4, Nome = "Santa casa dos Animais"},
            new Models.Clinica{Id = 5, Nome = "Consulvet Clínica Veterinária"},
            new Models.Clinica{Id = 6, Nome = "Hospital Veterinário É o Bicho 24h"},
            new Models.Clinica{Id = 7, Nome = "Veterinários Maceió+"},
            new Models.Clinica{Id = 8, Nome = "Pronto Socorro dos Animais"},
            new Models.Clinica{Id = 9, Nome = "Clínica Veterinária-24 Horass"}
        };

        public async Task<ObservableRangeCollection<Models.Clinica>> Get()
        {
            await Task.Delay(10);

            return clinicas;
        }
    }
}
