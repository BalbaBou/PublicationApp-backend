using Microsoft.AspNetCore.Mvc;
using PA.Interfaces;

namespace PublicationApp.Controllers;
//контроллеры возвращают объекты типа данных view result


public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(IDepartmentService departmentService)
    {//конструктор
        _departmentService = departmentService;
    }
    
    
    
}