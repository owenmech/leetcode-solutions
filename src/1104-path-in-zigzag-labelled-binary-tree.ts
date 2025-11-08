function pathInZigZagTree(label: number): number[] {
  if (label === 1) return [1]
  const row = Math.floor(Math.log2(label))
  const floor = Math.pow(2, row)
  const nextFloor = floor / 2
  const group = Math.floor((label - floor) / 2)
  const next = nextFloor - group - 1 + nextFloor
  return [...pathInZigZagTree(next), label]
}
