namespace bench;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Benchs
{
    public static string base64Url =
        "DQo8IWRvY3R5cGUgaHRtbD48aHRtbCBsYW5nPSJlbi1VUyIgcHJlZml4PSJvZzogaHR0cHM6Ly9vZ3AubWUvbnMjIj48aGVhZD48bWV0YSBjaGFyc2V0PSJ1dGYtOCIvPjxtZXRhIG5hbWU9InZpZXdwb3J0IiBjb250ZW50PSJ3aWR0aD1kZXZpY2Utd2lkdGgsaW5pdGlhbC1zY2FsZT0xIi8-PGxpbmsgcmVsPSJpY29uIiBocmVmPSIvZmF2aWNvbi00OHg0OC5jYmJkMTYxYi5wbmciLz48bGluayByZWw9ImFwcGxlLXRvdWNoLWljb24iIGhyZWY9Ii9hcHBsZS10b3VjaC1pY29uLjY4MDNjNmYwLnBuZyIvPjxtZXRhIG5hbWU9InRoZW1lLWNvbG9yIiBjb250ZW50PSIjZmZmZmZmIi8-PGxpbmsgcmVsPSJtYW5pZmVzdCIgaHJlZj0iL21hbmlmZXN0LjU2YjFjZWRjLmpzb24iLz48bGluayByZWw9InNlYXJjaCIgdHlwZT0iYXBwbGljYXRpb24vb3BlbnNlYXJjaGRlc2NyaXB0aW9uK3htbCIgaHJlZj0iL29wZW5zZWFyY2gueG1sIiB0aXRsZT0iTUROIFdlYiBEb2NzIi8-PHRpdGxlPldpbmRvd0Jhc2U2NC5idG9hKCkgLSBSw6lmw6lyZW5jZSBXZWIgQVBJIHwgTUROPC90aXRsZT48bGluayByZWw9ImFsdGVybmF0ZSIgdGl0bGU9ImJ0b2EoKSBnbG9iYWwgZnVuY3Rpb24iIGhyZWY9Imh0dHBzOi8vZGV2ZWxvcGVyLm1vemlsbGEub3JnL2VuLVVTL2RvY3MvV2ViL0FQSS9idG9hIiBocmVmbGFuZz0iZW4iLz48bGluayByZWw9ImFsdGVybmF0ZSIgdGl0bGU9IkNhZGVuYXMgYmluYXJpYXMiIGhyZWY9Imh0dHBzOi8vZGV2ZWxvcGVyLm1vemlsbGEub3JnL2VzL2RvY3MvV2ViL0FQSS9idG9hIiBocmVmbGFuZz0iZXMiLz48bGluayByZWw9ImFsdGVybmF0ZSIgdGl0bGU9ImJ0b2EoKSIgaHJlZj0iaHR0cHM6Ly9kZXZlbG9wZXIubW96aWxsYS5vcmcvamEvZG9jcy9XZWIvQVBJL2J0b2EiIGhyZWZsYW5nPSJqYSIvPjxsaW5rIHJlbD0iYWx0ZXJuYXRlIiB0aXRsZT0iYnRvYSgpIiBocmVmPSJodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9rby9kb2NzL1dlYi9BUEkvYnRvYSIgaHJlZmxhbmc9ImtvIi8-PGxpbmsgcmVsPSJhbHRlcm5hdGUiIHRpdGxlPSJXaW5kb3dCYXNlNjQuYnRvYSgpIiBocmVmPSJodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9ydS9kb2NzL1dlYi9BUEkvYnRvYSIgaHJlZmxhbmc9InJ1Ii8-PGxpbmsgcmVsPSJhbHRlcm5hdGUiIHRpdGxlPSJidG9hKCkiIGhyZWY9Imh0dHBzOi8vZGV2ZWxvcGVyLm1vemlsbGEub3JnL3poLUNOL2RvY3MvV2ViL0FQSS9idG9hIiBocmVmbGFuZz0iemgiLz48bGluayByZWw9ImFsdGVybmF0ZSIgdGl0bGU9IldpbmRvd0Jhc2U2NC5idG9hKCkiIGhyZWY9Imh0dHBzOi8vZGV2ZWxvcGVyLm1vemlsbGEub3JnL2ZyL2RvY3MvV2ViL0FQSS9idG9hIiBocmVmbGFuZz0iZnIiLz48bGluayByZWw9ImFsdGVybmF0ZSIgdHlwZT0iYXBwbGljYXRpb24vcnNzK3htbCIgdGl0bGU9Ik1ETiBCbG9nIFJTUyBGZWVkIiBocmVmPSIvZW4tVVMvYmxvZy9yc3MueG1sIiBocmVmbGFuZz0iZW4iIC8-PG1ldGEgbmFtZT0icm9ib3RzIiBjb250ZW50PSJpbmRleCwgZm9sbG93Ij48bWV0YSBuYW1lPSJkZXNjcmlwdGlvbiIgY29udGVudD0iTGEgbcOpdGhvZGUgV2luZG93T3JXb3JrZXJHbG9iYWxTY29wZS5idG9hKCkgY3LDqWUgdW5lIGNoYcOubmUgQVNDSUkgY29kw6llIGVuIGJhc2UgNjQgw6AgcGFydGlyIGQmYXBvczt1biBvYmpldCBTdHJpbmcgZGFucyBsZXF1ZWwgY2hhcXVlIGNhcmFjdMOocmUgZGUgbGEgY2hhw65uZSBlc3QgdHJhaXTDqSBjb21tZSB1biBvY3RldCBkZSBkb25uw6llcyBiaW5haXJlcy4iLz48bWV0YSBwcm9wZXJ0eT0ib2c6dXJsIiBjb250ZW50PSJodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9mci9kb2NzL1dlYi9BUEkvYnRvYSIvPjxtZXRhIHByb3BlcnR5PSJvZzp0aXRsZSIgY29udGVudD0iV2luZG93QmFzZTY0LmJ0b2EoKSAtIFLDqWbDqXJlbmNlIFdlYiBBUEkgfCBNRE4iLz48bWV0YSBwcm9wZXJ0eT0ib2c6bG9jYWxlIiBjb250ZW50PSJmciIvPjxtZXRhIHByb3BlcnR5PSJvZzpkZXNjcmlwdGlvbiIgY29udGVudD0iTGEgbcOpdGhvZGUgV2luZG93T3JXb3JrZXJHbG9iYWxTY29wZS5idG9hKCkgY3LDqWUgdW5lIGNoYcOubmUgQVNDSUkgY29kw6llIGVuIGJhc2UgNjQgw6AgcGFydGlyIGQmYXBvczt1biBvYmpldCBTdHJpbmcgZGFucyBsZXF1ZWwgY2hhcXVlIGNhcmFjdMOocmUgZGUgbGEgY2hhw65uZSBlc3QgdHJhaXTDqSBjb21tZSB1biBvY3RldCBkZSBkb25uw6llcyBiaW5haXJlcy4iLz48bWV0YSBwcm9wZXJ0eT0ib2c6aW1hZ2UiIGNvbnRlbnQ9Imh0dHBzOi8vZGV2ZWxvcGVyLm1vemlsbGEub3JnL21kbi1zb2NpYWwtc2hhcmUuY2Q2YzRhNWEucG5nIi8-PG1ldGEgbmFtZT0idHdpdHRlcjpjYXJkIiBjb250ZW50PSJzdW1tYXJ5X2xhcmdlX2ltYWdlIi8-PG1ldGEgbmFtZT0idHdpdHRlcjpjcmVhdG9yIiBjb250ZW50PSJNb3pEZXZOZXQiLz48bGluayByZWw9ImNhbm9uaWNhbCIgaHJlZj0iaHR0cH";
    [Benchmark]
    public string StringReplace()
    {
        var padRight = base64Url.Replace('-', '+')
            .Replace('_', '/')
            .PadRight(4 * ((base64Url.Length + 3) / 4), '=');
        return padRight;
    }

    [Benchmark]
    public string StringCreate()
    {
        int length = 4 * ((base64Url.Length + 3) / 4);
        var result = string.Create(length, base64Url, (chars, buffer) =>
        {
            buffer.AsSpan().CopyTo(chars);
            for (int i = 0; i < base64Url.Length; i++)
            {
                if (buffer[i] == '-')
                {
                    chars[i] = '+';
                }
                else if (buffer[i] == '_')
                {
                    chars[i] = '/';
                }
            }

            for (int i = base64Url.Length; i < chars.Length; i++)
            {
                chars[i] = '=';
            }
        });

        return result;
    }

}
