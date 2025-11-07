function avoidFlood(rains: number[]): number[] {
    const answer = rains.map(_ => -1)
    const dryDays: number[] = []
    const fullLakes: Record<number, number> = {} // lake -> day filled
    for (let today = 0; today < rains.length; today++) {
        const lake = rains[today]
        if (lake === 0) {
            dryDays.push(today)
        } else {
            const dayFilled = fullLakes[lake]
            if (dayFilled !== undefined) {
                const earliestDryDayIdx = dryDays.findIndex(dd => dd > dayFilled) // could binary search
                if (earliestDryDayIdx === -1) {
                    return []
                }
                const earliestDryDay = dryDays[earliestDryDayIdx]
                dryDays.splice(earliestDryDayIdx, 1)
                answer[earliestDryDay] = lake
            }

            fullLakes[lake] = today
        }
    }
    dryDays.forEach((day) => {
        answer[day] = 1
    })
    return answer
}
