﻿using DevFreela.Application.Commands.CreateProjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectsCommand>
    {
        public CreateProjectCommandValidator() 
        {
            RuleFor(p => p.Description)
                .MinimumLength(255)
                .WithMessage("Tamanho máximo de descrição é de 255 caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de descrição é de 30 caracteres.");
        }
    }
}
