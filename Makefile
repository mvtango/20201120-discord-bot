SHELL := /bin/bash

.SHELLFLAGS := -ecuo pipefail
.ONESHELL:

run:
	dotnet run
