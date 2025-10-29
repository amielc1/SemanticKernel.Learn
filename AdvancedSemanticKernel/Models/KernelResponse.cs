using Microsoft.KernelMemory;

namespace AdvancedSemanticKernel.Models
{
    public class KernelResponse
    {
        public string Answer { get; set; }
        public List<Citation> Citations { get; set; }
    }
}
