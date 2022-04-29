using DFE.Core.Io;
using DFE.Core.Node;
using DFE.Core.Utility;
using DFE.Core.VisualObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFE.Core.Document
{
    public sealed class Document
        : IExtendedStorageContainer, IDfeSerializable, ICloneable, IDisposable
    {
        private Document()
        {
        }
        private readonly List<INodeBase> _nodes = new();
        private readonly List<IVisualObject> _visualObjects = new();

        private static IVisualObject GetVisualRepresentationOfNodeOrNull(INodeBase node)
        {
            if (!node.TryGetVisualRepresentation(out var visualObj))
                return null;
            return visualObj;
        }
        /// <summary>
        /// ID of the document. It's created during creation and never changes later.
        /// It can be used to identifiy documents quickly. Cloned documents will have different IDs.
        /// However due to the internal implementation and collision of <see cref="System.Guid"/>, the property is not cryptographically unique.
        /// </summary>
        public Guid Id { get; private set; } = Guid.Empty;
        /// <summary>
        /// Extended information of the document.
        /// </summary>
        public ExtendedStorage ExtendedInformation { get; private set; } = new();
        /// <summary>
        /// Get computable nodes in the document.
        /// </summary>
        public IReadOnlyCollection<INodeBase> Nodes => _nodes.AsReadOnly();
        /// <summary>
        /// Get visual-only objects in the document.
        /// </summary>
        public IReadOnlyCollection<IVisualObject> VisualObjects => _visualObjects.AsReadOnly();
        /// <summary>
        /// Get all visual objects in the document, which include visual-only objects and potential ones derived from nodes.
        /// </summary>
        /// <returns>All existings visual objects in the document</returns>
        public IEnumerable<IVisualObject> GetVisualRepresentations()
        {
            var visualObjsOfNodes = _nodes
                .Select(GetVisualRepresentationOfNodeOrNull)
                .OfType<IVisualObject>();

            return _visualObjects.Concat(visualObjsOfNodes);
        }
        /// <summary>
        /// Create an empty document and prepare it correctly.
        /// </summary>
        /// <returns>An empty document with important fields initialized.</returns>
        public static Document CreateEmpty()
        {
            var doc = new Document
            {
                Id = Guid.NewGuid()
            };
            return doc;
        }

        /// <summary>
        /// Creates a copy of the current document. All internal nodes are cloned as well.
        /// ID of the document will change.
        /// </summary>
        /// <returns>A cloned document</returns>
        public Document Clone()
        {
            var clonedDoc = Document.CreateEmpty();

            clonedDoc.ExtendedInformation = (ExtendedStorage)ExtendedInformation.Clone();

            // _visualObjects.CloneTo(clonedDoc._visualObjects);
            // _nodes.CloneTo(clonedDoc._nodes);

            return clonedDoc;
        }
        object ICloneable.Clone()
            => Clone();
        /// <summary>
        /// Clear objects in the document.
        /// </summary>
        public void Clear()
        {
            DisposeInternalObjectList();
            _visualObjects.Clear();
            _nodes.Clear();
        }
        private void DisposeInternalObjectList()
        {
            _visualObjects.Dispose();
            _nodes.Dispose();
        }
        public void Dispose()
        {
            DisposeInternalObjectList();
        }
    }
}
