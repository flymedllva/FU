set.seed(100)
N<-10^6
X <- rpois(n=N,4)
Z <- rep(0,N)
for(i in 1:N){
Z[i] <- sum(rnorm(X[i],mean=8500,sd=259.3))
}
mean(Z)
sd(Z)
