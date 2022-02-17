function combinationSum(candidates: number[], target: number): number[][] {
  let allStack: number[][] = [];
  traverse(candidates, target, [], allStack, 0);

  return allStack;
};

function traverse(candidates: number[], target: number, currentStack: number[], allStack: number[][], startIter: number) {
  if (target === 0) {
    allStack.push([...currentStack]);
    return true;
  }
  if (target < 0) {
    return false;
  }

  for (let i = startIter; i < candidates.length; i++) {
    target -= candidates[i];
    currentStack.push(candidates[i]);

    traverse(candidates, target, currentStack, allStack, i);

    currentStack.pop();
    target += candidates[i];
  }

  return false;
}


console.log(combinationSum([2, 3, 6, 7], 7));
console.log(combinationSum([2,3,5], 8));