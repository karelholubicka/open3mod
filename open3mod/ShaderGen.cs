///////////////////////////////////////////////////////////////////////////////////
// Open 3D Model Viewer (open3mod) (v2.0)
// [ShaderGen.cs]
// (c) 2012-2015, Open3Mod Contributors
//
// Licensed under the terms and conditions of the 3-clause BSD license. See
// the LICENSE file in the root folder of the repository for the details.
//
// HIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
///////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace open3mod
{
    public class ShaderGen : IDisposable
    {
        [Flags]
        public enum GenFlags
        {
            TwoSide = 0x1,
            VertexColor = 0x2,
            PhongSpecularShading = 0x4,
            Skinning = 0x8,
            Lighting = 0x10
                //..so lightCount is added as lightCount*0x20+flag
        };

        private readonly Dictionary<GenFlags, Shader> shaders_ = new Dictionary<GenFlags, Shader>();

        public Shader GenerateOrGetFromCache(GenFlags flags, int lightCount)
        {
            int byteShift = 0x20;
            if (!shaders_.ContainsKey(flags + lightCount * byteShift))
            {
                shaders_[flags+lightCount* byteShift] = Generate(flags, lightCount);
            }
            return shaders_[flags + lightCount * byteShift];
        }

        public void Dispose()
        {
            foreach (var v in shaders_)
            {
                v.Value.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public Shader Generate( GenFlags flags, int lightCount) 
        {
            string pp = "";

            if (lightCount > 0)
            {
                pp += "#define NR_LIGHTS " + lightCount.ToString()+"\n";
            }

            if (flags.HasFlag(GenFlags.TwoSide))
            {
                pp += "#define HAS_TWOSIDE\n";
            }

            if (flags.HasFlag(GenFlags.VertexColor))
            {
                pp += "#define HAS_VERTEX_COLOR\n";
            }

            if (flags.HasFlag(GenFlags.PhongSpecularShading))
            {
                pp += "#define HAS_PHONG_SPECULAR_SHADING\n";
            }

            if (flags.HasFlag(GenFlags.Skinning))
            {
                pp += "#define HAS_SKINNING\n";
            }

            if (flags.HasFlag(GenFlags.Lighting))
            {
                pp += "#define HAS_LIGHTING\n";
            }

           return Shader.FromResource("open3mod.Shaders.UberVertexShader.glsl", "open3mod.Shaders.UberFragmentShader.glsl", pp);
        }

    }
}

/* vi: set shiftwidth=4 tabstop=4: */ 