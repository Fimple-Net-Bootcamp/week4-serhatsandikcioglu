﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Entities;

namespace VirtualPetCare.Core.Interfaces
{
    public interface ISocialInteractionRepository
    {
        void Add(SocialInteraction socialInteraction);
    }
}
