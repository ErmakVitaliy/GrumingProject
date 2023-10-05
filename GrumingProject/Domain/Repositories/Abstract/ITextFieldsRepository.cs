﻿using GrumingProject.Domain.Entities;

namespace GrumingProject.Domain.Repositories.Absrtact
{
	public interface ITextFieldsRepository
	{
		IQueryable<TextField> GetTextFields();
		TextField GetTextFieldById(Guid id);
		TextField GetTextFieldByCodeWord(string codeWord);
		void SaveTextField(TextField entity);
		void DeleteTextField(Guid id);
	}
}
