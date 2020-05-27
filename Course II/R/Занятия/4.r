
install.packages("rootSolve")
library(rootSolve)

# 1
A <- matrix(c(1, -1, 3, 2), nrow = 2, byrow = TRUE)
B <- matrix(c(7, 16), nrow = 2)
det(A)
(solve(A, B))

# 2
A <- matrix(c(2, 3, 2, 3, -1, 1, -1, 2, 1), nrow = 3)
B <- matrix(c(0, 1, 4), nrow = 3)
det(A)
(solve(A, B))

# 3
A <- matrix(c(3, 2, 4, 4, -1, 3, -1, -2, -4), nrow = 3)
B <- matrix(c(5, 3, 1), nrow = 3)
det(A)
(solve(A, B))

# 4
multiroot(f = function(x){
  f1 <- (x[1] * x[2])^2 - 16 * x[1] * x[2] + 39;
  f2 <- x[1]^2 + x[2]^2 - 10;
  c(f1 = f2, f2 = f2)
}, start = c(39, -10), maxiter = 1000)

# 5
multiroot(f = function(x){
  f1 <- 3 * x[1]^2 * x[2]^2 + 2 * x[1]^2 - 3 * x[1] * x[2] - 7;
  f2 <- 10 * x[1]^2 * x[2]^2 + 3 * x[1]^2 - 20 * x[1] * x[2] - 3;
  c(f1 = f1, f2 = f2)
}, start = c(10, -10), maxiter = 1000)

# 6
multiroot(f = function(x){
              f1 <- x[1]^2 - 2 * x[2]^2 - x[1] * x[2] + 2 * x[1] - x[2] + 1;
              f2 <- 2 * x[1]^2 - x[2]^2 + x[1] * x[2] + 3 * x[2] - 5;
              c(f1 = f1, f2 = f2)
}, start = c(-10, -10), maxiter = 1000)

# 7
A <- matrix(c(2, 1, 5, 3), nrow = 2)
B <- matrix(c(4, 2, -6, 1), nrow = 2)
det(A)
(solve(A) %*% B)

# 8
A <- matrix(c(3, 5, -2, -4), nrow = 2)
B <- matrix(c(-1, -5, 2, 6), nrow = 2)
det(A)
(B %*% solve(A))

# 9
A <- matrix(c(2, 3, 1, 2), nrow = 2)
B <- matrix(c(-3, 5, 2, -3), nrow = 2)
C <- matrix(c(-2, 3, 4, -1), nrow = 2)
det(B)
det(A)
(solve(A) %*% C %*% solve(B))

# 10
A <- matrix(c(-1, 2, -3, 2, 9, -6, -3, -6, 0), nrow = 3)
B <- matrix(c(1, 2, -3, 1, 2, 4, 1, 0, -5), nrow = 3)
E <- diag(3)
(A %*% E %*% solve(B %*% B))