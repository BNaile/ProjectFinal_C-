﻿using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IAboutCountService

    {
        IResult Add(AboutCountCreateDto dto);
        IResult Delete(int id);
        IResult UpDate(AboutCountUpdateDto dto);
        IDataResult<List<AboutCount>> GetAll();
        IDataResult<AboutCount> GetById(int id);
    }
}
