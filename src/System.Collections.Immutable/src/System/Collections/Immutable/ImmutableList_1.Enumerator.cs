// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel;

namespace System.Collections.Immutable
{
    public sealed partial class ImmutableList<T>
    {
        /// <summary>
        /// Enumerates the contents of a binary tree.
        /// </summary>
        /// <remarks>
        /// This struct can and should be kept in exact sync with the other binary tree enumerators:
        /// <see cref="ImmutableList{T}.Enumerator"/>, <see cref="ImmutableSortedDictionary{TKey, TValue}.Enumerator"/>, and <see cref="ImmutableSortedSet{T}.Enumerator"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public struct Enumerator : IEnumerator<T>, IStrongEnumerator<T>
        {
            /// <summary>
            /// The height of the node at which the indexer is used to enumerate instead of the stack
            /// </summary>
            private const int NodeEnumerateByIndexHeight = 4;
            /// <summary>
            /// The builder being enumerated, if applicable.
            /// </summary>
            private readonly Builder _builder;

            /// <summary>
            /// The starting index of the collection at which to begin enumeration.
            /// </summary>
            private readonly int _startIndex;

            /// <summary>
            /// The number of elements to include in the enumeration.
            /// </summary>
            private readonly int _count;

            /// <summary>
            /// The number of elements left in the enumeration.
            /// </summary>
            private int _remainingCount;

            /// <summary>
            /// A value indicating whether this enumerator walks in reverse order.
            /// </summary>
            private readonly bool _reversed;

            /// <summary>
            /// The set being enumerated.
            /// </summary>
            private Node _root;

            /// <summary>
            /// The stack to use for enumerating the binary tree.
            /// </summary>
            private Node _stackSlot0;
            private Node _stackSlot1;
            private Node _stackSlot2;
            private Node _stackSlot3;
            private Node _stackSlot4;
            private Node _stackSlot5;
            private Node _stackSlot6;
            private Node _stackSlot7;
            private Node _stackSlot8;
            private Node _stackSlot9;
            private Node _stackSlot10;
            private Node _stackSlot11;
            private Node _stackSlot12;
            private Node _stackSlot13;
            private Node _stackSlot14;
            private Node _stackSlot15;
            private Node _stackSlot16;
            private Node _stackSlot17;
            private Node _stackSlot18;
            private Node _stackSlot19;
            private Node _stackSlot20;
            private Node _stackSlot21;
            private Node _stackSlot22;
            private Node _stackSlot23;
            private Node _stackSlot24;
            private Node _stackSlot25;
            private Node _stackSlot26;
            private Node _stackSlot27;
            private Node _stackSlot28;
            private Node _stackSlot29;
            private Node _stackSlot30;
            private Node _stackSlot31;
            private Node _stackSlot32;
            private Node _stackSlot33;
            private Node _stackSlot34;
            private Node _stackSlot35;
            private Node _stackSlot36;
            private Node _stackSlot37;
            private Node _stackSlot38;
            private Node _stackSlot39;
            private Node _stackSlot40;
            private Node _stackSlot41;
            private Node _stackSlot42;
            private Node _stackSlot43;
            private Node _stackSlot44;
            private Node _stackSlot45;
            private Node _stackSlot46;

            /// <summary>
            /// The index of the top of the stack
            /// </summary>
            private int _stackTopIndex;

            /// <summary>
            /// The node currently selected.
            /// </summary>
            private Node _current;


            /// <summary>
            /// The node currently being enumerated by index
            /// </summary>
            private Node _currentNodeEnumeratingByIndex;

            /// <summary>
            /// The enumeration index of the current node being enumerated by index
            /// </summary>
            private int _currentIndex;

            /// <summary>
            /// The version of the builder (when applicable) that is being enumerated.
            /// </summary>
            private int _enumeratingBuilderVersion;

            /// <summary>
            /// Initializes an <see cref="Enumerator"/> structure.
            /// </summary>
            /// <param name="root">The root of the set to be enumerated.</param>
            /// <param name="builder">The builder, if applicable.</param>
            /// <param name="startIndex">The index of the first element to enumerate.</param>
            /// <param name="count">The number of elements in this collection.</param>
            /// <param name="reversed"><c>true</c> if the list should be enumerated in reverse order.</param>
            internal Enumerator(Node root, Builder builder = null, int startIndex = -1, int count = -1, bool reversed = false)
            {
                Requires.NotNull(root, nameof(root));
                Requires.Range(startIndex >= -1, nameof(startIndex));
                Requires.Range(count >= -1, nameof(count));
                Requires.Argument(reversed || count == -1 || (startIndex == -1 ? 0 : startIndex) + count <= root.Count);
                Requires.Argument(!reversed || count == -1 || (startIndex == -1 ? root.Count - 1 : startIndex) - count + 1 >= 0);

                _root = root;
                _builder = builder;
                _current = null;
                _currentNodeEnumeratingByIndex = null;
                _startIndex = startIndex >= 0 ? startIndex : (reversed ? root.Count - 1 : 0);
                _currentIndex = _startIndex;
                _count = count == -1 ? root.Count : count;
                _remainingCount = _count;
                _reversed = reversed;
                _enumeratingBuilderVersion = builder != null ? builder.Version : -1;
                _stackSlot0 = default;
                _stackSlot1 = default;
                _stackSlot2 = default;
                _stackSlot3 = default;
                _stackSlot4 = default;
                _stackSlot5 = default;
                _stackSlot6 = default;
                _stackSlot7 = default;
                _stackSlot8 = default;
                _stackSlot9 = default;
                _stackSlot10 = default;
                _stackSlot11 = default;
                _stackSlot12 = default;
                _stackSlot13 = default;
                _stackSlot14 = default;
                _stackSlot15 = default;
                _stackSlot16 = default;
                _stackSlot17 = default;
                _stackSlot18 = default;
                _stackSlot19 = default;
                _stackSlot20 = default;
                _stackSlot21 = default;
                _stackSlot22 = default;
                _stackSlot23 = default;
                _stackSlot24 = default;
                _stackSlot25 = default;
                _stackSlot26 = default;
                _stackSlot27 = default;
                _stackSlot28 = default;
                _stackSlot29 = default;
                _stackSlot30 = default;
                _stackSlot31 = default;
                _stackSlot32 = default;
                _stackSlot33 = default;
                _stackSlot34 = default;
                _stackSlot35 = default;
                _stackSlot36 = default;
                _stackSlot37 = default;
                _stackSlot38 = default;
                _stackSlot39 = default;
                _stackSlot40 = default;
                _stackSlot41 = default;
                _stackSlot42 = default;
                _stackSlot43 = default;
                _stackSlot44 = default;
                _stackSlot45 = default;
                _stackSlot46 = default;
                _stackTopIndex = -1;
                if (_count > 0)
                {
                    this.ResetStack();
                }
            }

            /// <summary>
            /// The current element.
            /// </summary>
            public T Current
            {
                get
                {
                    if (_current != null)
                    {
                        return _current.Value;
                    }

                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            /// The current element.
            /// </summary>
            object System.Collections.IEnumerator.Current => this.Current;

            /// <summary>
            /// Advances enumeration to the next element.
            /// </summary>
            /// <returns>A value indicating whether there is another element in the enumeration.</returns>
            public bool MoveNext()
            {
                this.ThrowIfChanged();

                if (_count > 0)
                {
                    if (_remainingCount > 0)
                    {
                        if (_currentIndex >= _currentNodeEnumeratingByIndex.Count)
                        {
                            Node n = PopFromStack();
                            if (n == null)
                            {
                                _current = null;
                                return false;
                            }

                            this.PushNext(this.NextBranch(n));
                            _current = n;
                        }
                        else
                        {
                            _current = _currentNodeEnumeratingByIndex.GetNodeAtIndex(_reversed ? _currentNodeEnumeratingByIndex.Count - _currentIndex - 1 : _currentIndex);
                            _currentIndex++;
                        }
                        _remainingCount--;
                        return true;
                    }
                }

                _current = null;
                return false;
            }

            /// <summary>
            /// Restarts enumeration.
            /// </summary>
            public void Reset()
            {
                _enumeratingBuilderVersion = _builder != null ? _builder.Version : -1;
                _remainingCount = _count;
                if (_count > 0)
                {
                    this.ResetStack();
                }
            }

            /// <summary>Resets the stack used for enumeration.</summary>
            private void ResetStack()
            {
                _stackTopIndex = -1;

                var node = _root;
                var skipNodes = _reversed ? _root.Count - _startIndex - 1 : _startIndex;
                while (node.Height > NodeEnumerateByIndexHeight && skipNodes != this.PreviousBranch(node).Count)
                {
                    if (skipNodes < this.PreviousBranch(node).Count)
                    {
                        PushToStack(node);
                        node = this.PreviousBranch(node);
                    }
                    else
                    {
                        skipNodes -= this.PreviousBranch(node).Count + 1;
                        node = this.NextBranch(node);
                    }
                }

                _currentNodeEnumeratingByIndex = node;
                _currentIndex = skipNodes;
            }

            /// <summary>
            /// Obtains the right branch of the given node (or the left, if walking in reverse).
            /// </summary>
            private Node NextBranch(Node node) => _reversed ? node.Left : node.Right;

            /// <summary>
            /// Obtains the left branch of the given node (or the right, if walking in reverse).
            /// </summary>
            private Node PreviousBranch(Node node) => _reversed ? node.Right : node.Left;

            /// <summary>
            /// Throws an exception if the underlying builder's contents have been changed since enumeration started.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">Thrown if the collection has changed.</exception>
            private void ThrowIfChanged()
            {
                if (_builder != null && _builder.Version != _enumeratingBuilderVersion)
                {
                    throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
                }
            }

            /// <summary>
            /// Pushes this node and all its Left descendants onto the stack.
            /// </summary>
            /// <param name="node">The starting node to push onto the stack.</param>
            private void PushNext(Node node)
            {
                int count = node.Height - NodeEnumerateByIndexHeight;
                while (count-- > 0)
                {
                    PushToStack(node);
                    node = this.PreviousBranch(node);
                }
                _currentIndex = 0;
                _currentNodeEnumeratingByIndex = node;
            }

            /// <summary>
            /// No-op dispose
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Pushes a node to the enumerator stack
            /// </summary>
            /// <param name="node"></param>
            private void PushToStack(Node node)
            {
                _stackTopIndex++;
                switch (_stackTopIndex)
                {
                    case 0:
                        _stackSlot0 = node;
                        break;
                    case 1:
                        _stackSlot1 = node;
                        break;
                    case 2:
                        _stackSlot2 = node;
                        break;
                    case 3:
                        _stackSlot3 = node;
                        break;
                    case 4:
                        _stackSlot4 = node;
                        break;
                    case 5:
                        _stackSlot5 = node;
                        break;
                    case 6:
                        _stackSlot6 = node;
                        break;
                    case 7:
                        _stackSlot7 = node;
                        break;
                    case 8:
                        _stackSlot8 = node;
                        break;
                    case 9:
                        _stackSlot9 = node;
                        break;
                    case 10:
                        _stackSlot10 = node;
                        break;
                    case 11:
                        _stackSlot11 = node;
                        break;
                    case 12:
                        _stackSlot12 = node;
                        break;
                    case 13:
                        _stackSlot13 = node;
                        break;
                    case 14:
                        _stackSlot14 = node;
                        break;
                    case 15:
                        _stackSlot15 = node;
                        break;
                    case 16:
                        _stackSlot16 = node;
                        break;
                    case 17:
                        _stackSlot17 = node;
                        break;
                    case 18:
                        _stackSlot18 = node;
                        break;
                    case 19:
                        _stackSlot19 = node;
                        break;
                    case 20:
                        _stackSlot20 = node;
                        break;
                    case 21:
                        _stackSlot21 = node;
                        break;
                    case 22:
                        _stackSlot22 = node;
                        break;
                    case 23:
                        _stackSlot23 = node;
                        break;
                    case 24:
                        _stackSlot24 = node;
                        break;
                    case 25:
                        _stackSlot25 = node;
                        break;
                    case 26:
                        _stackSlot26 = node;
                        break;
                    case 27:
                        _stackSlot27 = node;
                        break;
                    case 28:
                        _stackSlot28 = node;
                        break;
                    case 29:
                        _stackSlot29 = node;
                        break;
                    case 30:
                        _stackSlot30 = node;
                        break;
                    case 31:
                        _stackSlot31 = node;
                        break;
                    case 32:
                        _stackSlot32 = node;
                        break;
                    case 33:
                        _stackSlot33 = node;
                        break;
                    case 34:
                        _stackSlot34 = node;
                        break;
                    case 35:
                        _stackSlot35 = node;
                        break;
                    case 36:
                        _stackSlot36 = node;
                        break;
                    case 37:
                        _stackSlot37 = node;
                        break;
                    case 38:
                        _stackSlot38 = node;
                        break;
                    case 39:
                        _stackSlot39 = node;
                        break;
                    case 40:
                        _stackSlot40 = node;
                        break;
                    case 41:
                        _stackSlot41 = node;
                        break;
                    case 42:
                        _stackSlot42 = node;
                        break;
                    case 43:
                        _stackSlot43 = node;
                        break;
                    case 44:
                        _stackSlot44 = node;
                        break;
                    case 45:
                        _stackSlot45 = node;
                        break;
                    case 46:
                        _stackSlot46 = node;
                        break;
                }
            }

            /// <summary>
            /// Pops a node from the enumerator stack
            /// </summary>
            private Node PopFromStack()
            {
                var index = _stackTopIndex;
                _stackTopIndex--;
                switch (index)
                {
                    case 0:
                        return _stackSlot0;
                    case 1:
                        return _stackSlot1;
                    case 2:
                        return _stackSlot2;
                    case 3:
                        return _stackSlot3;
                    case 4:
                        return _stackSlot4;
                    case 5:
                        return _stackSlot5;
                    case 6:
                        return _stackSlot6;
                    case 7:
                        return _stackSlot7;
                    case 8:
                        return _stackSlot8;
                    case 9:
                        return _stackSlot9;
                    case 10:
                        return _stackSlot10;
                    case 11:
                        return _stackSlot11;
                    case 12:
                        return _stackSlot12;
                    case 13:
                        return _stackSlot13;
                    case 14:
                        return _stackSlot14;
                    case 15:
                        return _stackSlot15;
                    case 16:
                        return _stackSlot16;
                    case 17:
                        return _stackSlot17;
                    case 18:
                        return _stackSlot18;
                    case 19:
                        return _stackSlot19;
                    case 20:
                        return _stackSlot20;
                    case 21:
                        return _stackSlot21;
                    case 22:
                        return _stackSlot22;
                    case 23:
                        return _stackSlot23;
                    case 24:
                        return _stackSlot24;
                    case 25:
                        return _stackSlot25;
                    case 26:
                        return _stackSlot26;
                    case 27:
                        return _stackSlot27;
                    case 28:
                        return _stackSlot28;
                    case 29:
                        return _stackSlot29;
                    case 30:
                        return _stackSlot30;
                    case 31:
                        return _stackSlot31;
                    case 32:
                        return _stackSlot32;
                    case 33:
                        return _stackSlot33;
                    case 34:
                        return _stackSlot34;
                    case 35:
                        return _stackSlot35;
                    case 36:
                        return _stackSlot36;
                    case 37:
                        return _stackSlot37;
                    case 38:
                        return _stackSlot38;
                    case 39:
                        return _stackSlot39;
                    case 40:
                        return _stackSlot40;
                    case 41:
                        return _stackSlot41;
                    case 42:
                        return _stackSlot42;
                    case 43:
                        return _stackSlot43;
                    case 44:
                        return _stackSlot44;
                    case 45:
                        return _stackSlot45;
                    case 46:
                        return _stackSlot46;
                }

                return null;
            }

        }
    }
}
