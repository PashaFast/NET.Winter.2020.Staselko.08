using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    /// <summary>
    /// Interfact IView.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Method Render.
        /// </summary>
        /// <param name="text">Input text.</param>
        void Render(params string[] text);
    }
}
