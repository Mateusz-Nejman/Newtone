﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public interface ITimerContent
    {
        void Tick();
        void Appearing();
        void Disappearing();
    }
}
