using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 원숭이 데이터 관리를 위한 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new List<Monkey>();
    private static int randomPickCount = 0;
    private static readonly object lockObj = new object();

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 불러옵니다.
    /// </summary>
    public static void LoadMonkeys(IEnumerable<Monkey> monkeyData)
    {
        lock (lockObj)
        {
            monkeys = monkeyData.ToList();
        }
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys()
    {
        lock (lockObj)
        {
            return monkeys.AsReadOnly();
        }
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        lock (lockObj)
        {
            return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

    /// <summary>
    /// 랜덤 원숭이를 반환하고, 호출 횟수를 증가시킵니다.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        lock (lockObj)
        {
            if (monkeys.Count == 0) return null;
            var random = new Random();
            var monkey = monkeys[random.Next(monkeys.Count)];
            randomPickCount++;
            return monkey;
        }
    }

    /// <summary>
    /// 랜덤 원숭이 선택 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount()
    {
        lock (lockObj)
        {
            return randomPickCount;
        }
    }
}
