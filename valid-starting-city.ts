export function validStartingCity(distances: number[], fuel: number[], mpg: number) {

  for (let i = 0; i < distances.length; i++) {
    let fuelLeft = fuel[i]*mpg;
    let c1 = 0;
    let c2 = i + 1;
    console.log(`----------${i}---------`);
    while (c2 < distances.length || c1 < i) {
      let distanceTravelled = 0;
      let currentFuel = 0;
      if (c2 < distances.length) {
        distanceTravelled = distances[c2 - 1];
        currentFuel = fuel[c2];
        c2++;
      } else {
        distanceTravelled = c1 == 0 ? distances[distances.length - 1] : distances[c1 - 1];
        currentFuel = fuel[c1];
        c1++;
      }
      fuelLeft -= (distanceTravelled);
      console.log(`fuel left - ${fuelLeft}`);
      if(fuelLeft < 0) break;
      fuelLeft += currentFuel * mpg;
    }
    if (fuelLeft >= 0) return i;
  }

  return -1;
}

console.log(validStartingCity(
  [30, 40, 10, 10, 17, 13, 50, 30, 10, 40],
  [1,   2, 0,  1, 1, 0, 3, 1, 0, 1],
  25));