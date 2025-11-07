function peopleAwareOfSecret(n: number, delay: number, forget: number): number {
  const MOD = 1000000007
  const learned = Array.from({length: n + 1}, _ => 0)
  learned[1] = 1
  let onDelay = 1
  let sharing = 0
  for (let day = 2; day <= n; day++) {
    const offDelay = learned[day - delay] ?? 0
    const forgot = learned[day - forget] ?? 0
    sharing = (sharing + offDelay - forgot + MOD) % MOD
    onDelay = (onDelay - offDelay + sharing + MOD) % MOD
    learned[day] = sharing
  }
  return (onDelay + sharing + MOD) % MOD
}
