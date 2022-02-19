export function minimumPassesOfMatrix(matrix: number[][]) {

	let totalPasses = 0;
	let visited = new Set<string>();
	let initialPositiveSet: number[][] = [];
	let initialNegativeSet: number[][] = [];

	for (let r = 0; r < matrix.length; r++) {
		for (let c = 0; c < matrix[r].length; c++) {
			if(matrix[r][c] > 0) initialPositiveSet.push([r, c]);
			if(matrix[r][c] < 0) initialNegativeSet.push([r, c]);
		}
	}

	let nextPasses = [ initialPositiveSet ];
	while(nextPasses.length > 0 && nextPasses[0].length > 0) {
		//console.log("---------------------------------------------------------");
		let currentPass = nextPasses.pop()!;
		let nextSet: number[][] = [];
		//console.log(matrix);
		for (let r = 0; r < currentPass.length; r++) {
			//console.log(`${currentPass[r][0]}  -  ${currentPass[r][1]}`);
			let rs = traverse(matrix, currentPass[r][0], currentPass[r][1], visited);
			//console.log(rs);
			nextSet.push(...rs);
		}
		
		// console.log(nextPasses);
		nextPasses.push(nextSet);
		makePositive(matrix, nextSet);
		if(nextSet.length > 0) totalPasses++;
	}

	for (let r = 0; r < initialNegativeSet.length; r++) {
		if(matrix[initialNegativeSet[r][0]][initialNegativeSet[r][1]] < 0) return -1;
	}
	
	return totalPasses;
}

function makePositive(matrix: number[][], negativeSet: number[][]) {
	for (let r = 0; r < negativeSet.length; r++) {
		if(matrix[negativeSet[r][0]][negativeSet[r][1]] < 0)
			matrix[negativeSet[r][0]][negativeSet[r][1]] *= -1;
	}
}

function traverse(matrix: number[][], row: number, column: number, visited: Set<string>): number[][] {

	if (visited.has(`${row},${column}`)) return [];

	let queue = [[row, column]];
	let nextPass = [];
	while (queue.length > 0) {
		let [currentRow, currentColumn] = queue.shift()!;

		if (currentRow < 0 || currentRow >= matrix.length) continue;
		if (currentColumn < 0 || currentColumn >= matrix[currentRow].length) continue;
		if (visited.has(`${currentRow},${currentColumn}`)) continue;

		if (matrix[currentRow][currentColumn] == 0) continue;
		else if (matrix[currentRow][currentColumn] < 0) {
			nextPass.push([currentRow, currentColumn]);
			continue;
		} else {
			visited.add(`${currentRow},${currentColumn}`);
			queue.push([currentRow - 1, currentColumn]);
			queue.push([currentRow + 1, currentColumn]);
			queue.push([currentRow, currentColumn + 1]);
			queue.push([currentRow, currentColumn - 1]);
		}
	}

	return nextPass;
}

console.log(minimumPassesOfMatrix(
	[
		[-2, -3, -4, -1, -9],
		[-4, -3, -4, -1, -2],
		[-6, -7, -2, -1, -1],
		[0, 0, 0, 0, -3],
		[1, -2, -3, -6, -1]
	]
));