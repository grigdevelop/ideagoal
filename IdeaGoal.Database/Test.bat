devenv /Rebuild $(SolutionDir)IdeaGoal.Database/IdeaGoal.Database.sqlproj

call "$(SolutionDir)IdeaGoal.Domain.UnitTests\deploy_db.cmd"