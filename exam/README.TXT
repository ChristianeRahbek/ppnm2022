Autor: Christiane Rahbek

Student number: 201804946

Exam question: 46%23 = 0

Description of project:
This projectt contains 3 important files that builds most of the code functionality:

'rayleigh.cs'
	This in this file the Rayleigh quotient is defined along with its derrivative.
'qn.cs'
	This is my modified quasinewton minimization. In the code there are some references
	to the equations in the chapter on Minimization to be able to follow along. I have 
	not done much to the code except for adding the renormalization factor.
'main.cs'
	In here I have tested my implementation. First I just made a random symmetric matrix
	with a random guess on the eigenvector. Afterwards i timed how the different matrix 
	sizes had an impact on the rumtime, this data has been plotted, and can be found in
	'scaling.png'. Lastly I found the ground state of the Hydrogen atom. To do so I 
	reused a function that I used in one of the Homeworks, where the Hamiltonian was
	defined. The choice of rmax = 10 also comes from the r-convergence we did in a 
	previous Homework. I made a 50x50 matrix, which was an arbitrary choise of a big 
	matrix to get presission on the eigenvalue. The overall steps can also be seen in 
	the 'Out.txt' file. 
