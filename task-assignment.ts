export function taskAssignment(k: number, tasks: number[]) {
  let assignment: number[][] = [];
  let t1Counter = 0, t2Counter = tasks.length - 1;
  let indexMap = getIndexMap(tasks);
  tasks.sort((a, b) => a - b);
  console.log(tasks);
  
  while (k-- > 0) {
    assignment.push([ indexMap.get(tasks[t1Counter++])?.shift()!, indexMap.get(tasks[t2Counter--])?.shift()! ]);
  }

  return assignment;
}

function getIndexMap(tasks: number[]): Map<number, number[]> {
  let map = new Map<number, number[]>();

  for(let i = 0; i < tasks.length; i++) {
    if(!map.has(tasks[i])) {
      map.set(tasks[i], []);
    }
    map.get(tasks[i])?.push(i);
  }

  return map;
}

console.log(taskAssignment(7, [2, 1, 3, 4, 5, 13, 12, 9, 11, 10, 6, 7, 14, 8]));