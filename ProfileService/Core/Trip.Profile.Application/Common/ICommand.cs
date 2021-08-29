using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Application.Common
{
    public class ICommand<T> : IRequest<T>
    {
    }
}
