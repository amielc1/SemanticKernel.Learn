using Microsoft.Extensions.VectorData;

namespace AdvancedSemanticKernel
{
    public sealed class Product
    {
        [VectorStoreRecordKey]
        public ulong ProductId { get; set; }

        [VectorStoreRecordData]
        public string Name { get; set; }

        [VectorStoreRecordData]
        public string Description { get; set; }

        [VectorStoreRecordVector(1536)]
        public ReadOnlyMemory<float> DescriptionEmbedding { get; set; }

        [VectorStoreRecordData(IsFilterable = true)]
        public string Category { get; set; }
    }
}
