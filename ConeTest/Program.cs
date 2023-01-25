using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kitware.VTK;

namespace ConeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConeTest1();
        }

        public static void ConeTest1()
        {
            vtkConeSource consource = vtkConeSource.New();
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(consource.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            vtkRenderer renderer = vtkRenderer.New();
            renderer.AddActor(actor);
            renderer.SetBackground(.1, .2, .3);
            renderer.ResetCamera();

            vtkRenderWindow renderWin = vtkRenderWindow.New();
            renderWin.AddRenderer(renderer);

            vtkRenderWindowInteractor interactor = vtkRenderWindowInteractor.New();
            interactor.SetRenderWindow(renderWin);

            renderWin.Render();
            interactor.Start();
        }
    }
}
