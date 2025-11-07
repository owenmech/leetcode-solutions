function numIslands(grid: string[][]): number {
    const tracker = grid.map(r => r.map(_ => false))

    const fill = (i: number, j: number) => {
        if (grid[i]?.[j] === undefined || grid[i][j] === "0" || tracker[i][j]) {
            return
        }
        tracker[i][j] = true
        fill(i, j + 1)
        fill(i, j - 1)
        fill(i + 1, j)
        fill(i - 1, j)
    }

    let count = 0
    grid.forEach((gridRow, y) => {
        gridRow.forEach((val, x) => {
            if (val === "0") return
            if (tracker[y][x]) return
            count++
            fill(y, x)
        })
    })

    return count
}
