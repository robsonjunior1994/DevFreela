using DevFreela.Application.Commands.DeleteProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .Must(ValidId)
                .WithMessage("Valor do Id não pode ser menor que 0");
        }

        private bool ValidId(int id)
        {
            if (id < 0)
                return false;
            return true;
        }
    }
}
