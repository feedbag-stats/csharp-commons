﻿/*
 * Copyright 2014 Technische Universität Darmstadt
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using KaVE.Commons.Model.Naming.IDEComponents;
using KaVE.Commons.Utils.Assertion;
using KaVE.JetBrains.Annotations;

namespace KaVE.Commons.Model.Naming.Impl.v0.IDEComponents
{
    public class ProjectName : BaseName, IProjectName
    {
        public ProjectName() : this("?") {}

        public ProjectName([NotNull] string identifier) : base(identifier)
        {
            if (!"?".Equals(identifier))
            {
                Asserts.That(identifier.Contains(" "), "id must contain a space");
            }
        }

        private string[] _parts;

        private string[] Parts
        {
            get { return _parts ?? (_parts = Identifier.Split(new[] {' '}, 2)); }
        }

        public string Type
        {
            get { return IsUnknown ? UnknownNameIdentifier : Parts[0]; }
        }

        public string Name
        {
            get { return IsUnknown ? UnknownNameIdentifier : Parts[1]; }
        }

        public override bool IsUnknown
        {
            get { return "?".Equals(Identifier); }
        }
    }
}