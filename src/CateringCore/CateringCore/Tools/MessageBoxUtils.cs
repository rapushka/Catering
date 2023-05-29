using System;
using System.Linq;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using static System.Windows.MessageBoxButton;
using static System.Windows.MessageBoxImage;
using static System.Windows.MessageBoxResult;

namespace OrganizerCore.Tools;

public static class MessageBoxUtils
{
	// ReSharper disable once InconsistentNaming - OK is OK
	private static MessageBoxButton OK => MessageBoxButton.OK;

	public static bool ConfirmDeletion<T>(T of)
		where T : Table
	{
		var dependentEntries = Dependencies.For(of);

		if (dependentEntries.Any() == false)
		{
			return true;
		}

		var entries = string.Join(",\n", dependentEntries);

		return ShowEnsure($"В базе данных остались связаные записи:\n{entries}\n\nПродолжить?");
	}

	public static void AtFirstSelect(string item) => ShowError($"Сначала выберите {item}!");

	public static bool ShowEnsure(string message)
	{
		var result = MessageBox.Show
		(
			messageBoxText: message,
			caption: "Предупреждение",
			button: YesNo,
			icon: Warning
		);
		return result == Yes;
	}

	public static void ShowError(string message)
		=> MessageBox.Show
		(
			messageBoxText: message,
			caption: "Ошибка",
			button: OK,
			icon: Error
		);

	public static void ShowInfo(string message)
		=> MessageBox.Show
		(
			messageBoxText: message,
			caption: "Успех",
			button: OK,
			icon: Information
		);

	public static void ShowOnSaveException(Exception ex)
	{
		var errorText = ex.InnerException is not null
			? ex.InnerException?.Message
			: ex.Message;

		ShowError($"Ошибка при сохранении изменений\nТекст ошибки: {errorText}");
	}
}