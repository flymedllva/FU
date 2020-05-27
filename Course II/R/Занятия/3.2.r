# 1
matrix(letters, ncol = 26, nrow = 2)[1,]
matrix(letters, ncol = 26, nrow = 2)[2,]

# 2
n <- 3
m <- matrix(letters, ncol = 26, nrow = n)[1,]
m

# 3
n <- 2
matrix(rep(paste0(letters[1:26], character(n)), times=(n * 2 - 1)), nrow=n, byrow=TRUE)[,1:n]

# 4
n <- 2
matrix(rep(paste0(letters[1:26], rep('', times = n))[1:n], times=(n * 2 - 1)), nrow=n, byrow=TRUE)[,1:n]

# 5
n <- 30
matrix(rep(paste0(letters[1:26], if (n > 25) character(n) else rep('', times = n)), times=(n * 2 - 1)), nrow=n, byrow=TRUE)[,1:n]
