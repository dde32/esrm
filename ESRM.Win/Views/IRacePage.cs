using ESRM.Entities;
using System;

namespace ESRM.Win.Views
{
    public interface IRacePage
    {
        void CurrentRaceLapRecordCommand(LaneIdEventArgs e);
        void CurrentRaceLowFuelCommand(LaneIdEventArgs e);
        void CurrentRaceLowHealthCommand(LaneIdEventArgs e);
        void CurrentRaceLowTiresCommand(LaneIdEventArgs e);
        void CurrentRaceOutOfFuelCommand(LaneIdEventArgs e);
        void CurrentRaceOutOfHealthCommand(LaneIdEventArgs e);
        void CurrentRaceOutOfTiresCommand(LaneIdEventArgs e);
        void CurrentRaceTeamEndRelayCommand(LaneIdEventArgs e);

        void RaceIncidentCommand(LaneIdEventArgs e);

        void RacePitStopBeginCommand(LaneIdEventArgs e);
        void RacePitStopEndedCommand(LaneIdEventArgs e);
        void RacePitStopRefreshCommand(LaneIdEventArgs e);

        void RaceTeamFinishCommand(LaneIdEventArgs e);
        void RefreshOneTeamCommand(Race datas, int teamId);
        void RefreshRaceBoardCommand();
        void TrackCallCommand(TeamIdEventArgs e);

        void StartButtonActionCommand();
        void RaceFinishedCommand();
        void RaceGreenFlagCommand();
        void RaceLapEndedCommand();
        void RaceStartedCommand();
        void RaceYellowFlagCommand();
        void RefreshDurationCommand();

        void ResfreshStartLightCommand();
        void ResfreshStarterCommand(int? count);
        void RefreshAfterPauseCommand();
        void RefreshAfterUnPauseCommand();
        void RefreshTimeAttackRaceTimeCommand();
        void RefreshConnectionStateCommand();
        void ResizeTeamsListCommand();
        void RefreshGridAfterTeamAdded();
        void RefresWeatherCommand();

        void PlayRainSoundCommand(SoundEnum sound);
        void StopRainSoundCommand();


    }
}