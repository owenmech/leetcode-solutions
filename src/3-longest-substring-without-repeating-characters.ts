function lengthOfLongestSubstring(s: string): number {
    const chars = s.split('')
    let best = 0
    let seen: string[] = []
    chars.forEach((c, i) => {
        const idx = seen.indexOf(c)
        if (idx === -1) {
            best = Math.max(best, seen.length + 1)
        } else {
            seen = seen.slice(idx + 1)
        }
        seen.push(c)
    })
    return best
}
