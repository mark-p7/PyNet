def getResult(pInput, rInput, nInput, tInput):
    if (pInput is None or rInput is None or nInput is None or tInput is None):
        return -1
    p = pInput
    r = rInput
    n = int(nInput)
    t = tInput
    if (len(str(p)) > 10 or len(str(r)) > 10 or len(str(n)) > 10 or len(str(t)) > 10):
        return -2
    if (n == 0):
        return -3
    if (p < 0 or r < 0 or n < 0 or t < 0):
        return -4
    output = p * ((1 + r / n) ** (n * t))
    return round(output, 2)

result = getResult(5000, 0.05, 12, 10)
print(result)