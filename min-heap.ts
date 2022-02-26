// Do not edit the class below except for the buildHeap,
// siftDown, siftUp, peek, remove, and insert methods.
// Feel free to add new properties and methods to the class.
export class MinHeap {
  heap: number[];

  constructor(array: number[]) {
    this.heap = [];
    this.buildHeap(array);
  }

  buildHeap(array: number[]) {
		for (let item of array) {
      this.insert(item);
    }
    return this.heap;
  }

  siftDown(currentIndex: number) {
    if (this.heap.length == 0) return;

    while (this.getLeftChildIndex(currentIndex) < this.heap.length) {
      let smallestChildIndex = this.getLeftChildIndex(currentIndex);
      let rightChildIndex = this.getRightChildIndex(currentIndex);
      if (this.heap.length > rightChildIndex
        && this.heap[smallestChildIndex] > this.heap[rightChildIndex]) {
        smallestChildIndex = rightChildIndex;
      }

      if (this.heap[smallestChildIndex] < this.heap[currentIndex]) {
        this.swap(this.heap, currentIndex, smallestChildIndex);
				currentIndex = smallestChildIndex;
      } else {
        break;
      }
    }
  }

  siftUp() {
    let currentIndex = this.heap.length - 1;
    let parentIndex = this.getParentIndex(currentIndex);
    while (parentIndex >= 0 && this.heap[parentIndex] > this.heap[currentIndex]) {
      this.swap(this.heap, parentIndex, currentIndex);
      currentIndex = parentIndex;
      parentIndex = this.getParentIndex(currentIndex);
    }
  }

  peek() {
    return this.heap.length > 0 ? this.heap[0] : null;
  }

  remove() {
		this.swap(this.heap, 0, this.heap.length - 1);
    let toRemove = this.heap.pop()!;
    this.siftDown(0);
    return toRemove;
  }

  insert(value: number) {
    this.heap.push(value);
    this.siftUp();
  }


  private getParentIndex(index: number): number {
    return Math.floor((index - 1) / 2);
  }

  private getLeftChildIndex(index: number): number {
    return index * 2 + 1;
  }

  private getRightChildIndex(index: number): number {
    return index * 2 + 2;
  }

  private swap(array: number[], i1: number, i2: number) {
    let t = array[i1];
    array[i1] = array[i2];
    array[i2] = t;
  }
}
