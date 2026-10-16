using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Tasks
{
    public class  TaskQuery : IRequest<Task>
    {
        public int id { get; set; }
    }
}